//
//  FOMViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMCommunicationHandler.h"
#import "FOMConfigurationProvider.h"
#import "FOMLoadingDialog.h"
#import "FOMOrder.h"
#import "FOMResponseParser.h"
#import "FOMRootViewController.h"

@interface FOMRootViewController ()

@end

@implementation FOMRootViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self.view addSubview:[[FOMLoadingDialog alloc] initWithFrame:self.view.frame]];
    [self fetchOrders];
}

- (void)fetchOrders
{
    [self showLoadingDialog];
    [self invokeFetchRemoteOrders];
}

- (void)showLoadingDialog
{
    self.loadingDialog = [[FOMLoadingDialog alloc] initWithFrame:self.view.frame];
    [self.view addSubview:self.loadingDialog];
    [self.loadingDialog startAnimating];
}

- (void)invokeFetchRemoteOrders
{
    FOMCommunicationHandler *communicationHandler = [[FOMCommunicationHandler alloc] init];
    [communicationHandler setDelegate:self];
    [communicationHandler startGetConnectionWithAddress:[FOMConfigurationProvider ordersServiceAddress]];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return 2;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return section == 0 ? 1 : [self.orders count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSString *cellIdentifier = indexPath.section == 0 ? @"NewOrder" : @"ExistingOrder";
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:cellIdentifier];
    
    if (cell != nil)
    {
        if (indexPath.section == 0)
        {
            cell.textLabel.text = NSLocalizedString(@"New Order", nil);
        }
        else
        {
            FOMOrder *order = [self.orders objectAtIndex:indexPath.row];
            cell.textLabel.text = order.name;
        }
    }
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == 0)
    {
        [self performSegueWithIdentifier:@"NewOrder" sender:self];
    }
    else
    {
        
    }
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section
{
    return 44.0;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section
{
    CGRect headerFrame = CGRectMake(0.0, 0.0, self.view.frame.size.width, 44.0);
    
    UIView *view = [[UIView alloc] initWithFrame:headerFrame];
    
    UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(10.0, headerFrame.origin.y, headerFrame.size.width, headerFrame.size.height)];
    label.font = [UIFont boldSystemFontOfSize:17.0];
    label.text = NSLocalizedString(section == 0 ? @"New Order Header" : @"Existing Order Header", nil);
    
    [view addSubview:label];
    
    return view;
}

- (void)communicationFinishedSuccessfully:(NSData *)sentData
{
    [self hideLoadingDialog];
    [self setOrdersFromResponse:sentData];
}

- (void)hideLoadingDialog
{
    [self.loadingDialog stopAnimating];
    [self.loadingDialog removeFromSuperview];
}

- (void)setOrdersFromResponse:(NSData *)response
{
    self.orders = [FOMResponseParser parseOrdersFromResponse:response];
    [self.tableView reloadData];
}

- (void)communicationFailedWithError:(NSError *)error
{
    [self hideLoadingDialog];
}

@end
