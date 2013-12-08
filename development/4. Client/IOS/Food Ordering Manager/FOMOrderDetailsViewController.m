//
//  FOMOrderDetailsViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMDateUtilities.h"
#import "FOMOrderDetailsViewController.h"
#import "FOMOrderItemsSelectionViewController.h"

@interface FOMOrderDetailsViewController ()

@end

@implementation FOMOrderDetailsViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
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
    return section == 0 ? 4 : 1;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSString *identifier = indexPath.section == 0 ? @"RightDetail" : @"ActionCell";
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:identifier];
    
    if (indexPath.section == 0)
    {
        NSString *leftText = @"";
        NSString *rightText = @"";
        
        if (indexPath.row == 0)
        {
            leftText = NSLocalizedString(@"Orderer", nil);
            rightText = self.order.orderer;
        }
        else if (indexPath.row == 1)
        {
            leftText = NSLocalizedString(@"Restaurant", nil);
            rightText = self.order.restaurant.name;
        }
        else if (indexPath.row == 2)
        {
            leftText = NSLocalizedString(@"Delivery Date", nil);
            rightText = [FOMDateUtilities dateToString:self.order.date];
        }
        else if (indexPath.row == 3)
        {
            leftText = NSLocalizedString(@"Status", nil);
            rightText = self.order.status;
        }
        
        cell.textLabel.text = leftText;
        cell.detailTextLabel.text = rightText;
    }
    else
    {
        cell.textLabel.text = NSLocalizedString(@"Account", nil);
    }
    
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    return 44.0;
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
    label.text = NSLocalizedString(section == 0 ? @"Details" : @"Actions", nil);
    
    [view addSubview:label];
    
    return view;
}

- (IBAction)addOrderItemsButtonPushed:(id)sender
{
    [self performSegueWithIdentifier:@"OrderItemsSelection" sender:self];
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([segue.identifier isEqualToString:@"OrderItemsSelection"])
    {
        FOMOrderItemsSelectionViewController *destinationViewController = segue.destinationViewController;
        destinationViewController.order = self.order;
    }
}

@end
