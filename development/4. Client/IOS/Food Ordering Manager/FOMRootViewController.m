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
#import "FOMOrderDetailsViewController.h"
#import "FOMResponseParser.h"
#import "FOMRootViewController.h"

@interface FOMRootViewController ()

@end

@implementation FOMRootViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self.view addSubview:[[FOMLoadingDialog alloc] initWithFrame:self.view.frame]];
}

- (void)viewDidAppear:(BOOL)animated
{
    [self fetchOrders];
}

- (void)fetchOrders
{
    [self showLoadingDialog];
    [self configureQueriesToComplete];
    [self invokeFetchMyOrders];
    [self invokeFetchAvailableOrders];
}

- (void)showLoadingDialog
{
    self.loadingDialog = [[FOMLoadingDialog alloc] initWithFrame:self.view.frame];
    [self.view addSubview:self.loadingDialog];
    [self.loadingDialog startAnimating];
}

- (void)configureQueriesToComplete
{
    self.queriesToComplete = [NSNumber numberWithInteger:2];
}

- (void)invokeFetchMyOrders
{
    FOMCommunicationHandler *communicationHandler = [[FOMCommunicationHandler alloc] init];
    [communicationHandler setDelegate:self];
    [communicationHandler startGetConnectionWithAddress:[FOMConfigurationProvider myOrdersServiceAddress]];
}

- (void)invokeFetchAvailableOrders
{
    FOMCommunicationHandler *communicationHandler = [[FOMCommunicationHandler alloc] init];
    [communicationHandler setDelegate:self];
    [communicationHandler startGetConnectionWithAddress:[FOMConfigurationProvider ordersServiceAddressForStatus:@"open"]];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return 3;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return section == 0 ? 1 : section == 1 ? [self.myOrders count] : [self.availableOrders count];
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
        else if (indexPath.section == 1)
        {
            FOMOrder *order = [self.myOrders objectAtIndex:indexPath.row];
            cell.textLabel.text = order.name;
        }
        else if (indexPath.section == 2)
        {
            FOMOrder *order = [self.availableOrders objectAtIndex:indexPath.row];
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
    else if (indexPath.section == 1)
    {
        self.selectedOrder = [self.myOrders objectAtIndex:indexPath.row];
        [self performSegueWithIdentifier:@"OrderDetails" sender:self];
    }
    else if (indexPath.section == 2)
    {
        self.selectedOrder = [self.availableOrders objectAtIndex:indexPath.row];
        [self performSegueWithIdentifier:@"OrderDetails" sender:self];
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
    label.text = NSLocalizedString(section == 0 ? @"New Order Header" : section == 1 ? @"My Order Header" : @"Available Order Header", nil);
    
    [view addSubview:label];
    
    return view;
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([segue.identifier isEqualToString:@"OrderDetails"])
    {
        FOMOrderDetailsViewController *destinationViewController = segue.destinationViewController;
        destinationViewController.order = self.selectedOrder;
    }
}

- (void)communicationForAddress:(NSString *)address finishedSuccessfullyWithResponse:(NSData *)sentData
{
    [self hideLoadingDialog];
    [self setOrdersFromResponse:sentData andAddress:address];
}

- (void)hideLoadingDialog
{
    self.queriesToComplete = [NSNumber numberWithInteger:[self.queriesToComplete intValue] - 1];
    
    if ([self.queriesToComplete integerValue] > 0)
    {
        return;
    }
    
    [self.loadingDialog stopAnimating];
    [self.loadingDialog removeFromSuperview];
}

- (void)setOrdersFromResponse:(NSData *)response andAddress:(NSString *)address
{
    NSArray *orders = [FOMResponseParser parseOrdersFromResponse:response];
    
    if ([address isEqualToString:[FOMConfigurationProvider myOrdersServiceAddress]])
    {
        self.myOrders = orders;
    }
    else
    {
        self.availableOrders = orders;
    }
    
    [self.tableView reloadData];
}

- (void)communicationForAddress:(NSString *)address failedWithError:(NSError *)error
{
    [self hideLoadingDialog];
}

@end
