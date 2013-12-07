//
//  FOMNewOrderViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMNewOrderViewController.h"
#import "FOMOrderItem.h"
#import "FOMRestaurantSelectionViewController.h"

@interface FOMNewOrderViewController ()

@end

@implementation FOMNewOrderViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self initializeOrder];
}

- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear:animated];
    [self.tableView reloadData];
}

- (void)initializeOrder
{
    self.order = [[FOMOrder alloc] init];
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
    NSUInteger orderCount = [self.order.items count];
    return section == 0 ? 2 : orderCount > 0 ? orderCount : 1;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:@"RightDetailCell"];
    
    if (indexPath.section == 0)
    {
        cell.textLabel.text = NSLocalizedString(indexPath.row == 0 ? @"Restaurant Name" : @"Order Date", nil);
        
        if (indexPath.row == 0)
        {
            cell.detailTextLabel.text = self.order.restaurant != nil ? self.order.restaurant.name : NSLocalizedString(@"Choose", nil);
        }
        else if (indexPath.row == 1)
        {
            cell.detailTextLabel.text = self.order.date != nil ? [self formatDate:self.order.date] : NSLocalizedString(@"Choose", nil);
        }
    }
    else if (indexPath.section == 1)
    {
        if ([self.order.items count] > 0)
        {
            FOMOrderItem *item = [self.order.items objectAtIndex:indexPath.row];
            
            cell.textLabel.text = [NSString stringWithFormat:NSLocalizedString(@"Order %d", nil), indexPath.row + 1];
            cell.detailTextLabel.text = item.dish;
        }
        else
        {
            cell.textLabel.text = NSLocalizedString(@"No Order Entries", nil);
            cell.detailTextLabel.text = @"";
            cell.accessoryType = UITableViewCellAccessoryNone;
        }
    }
    
    return cell;
}

- (NSString *)formatDate:(NSDate *)date
{
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    formatter.dateFormat = @"hh:MM";
    
    return [formatter stringFromDate:date];
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
    label.text = NSLocalizedString(section == 0 ? @"Order Details" : @"Order Entries", nil);
    
    [view addSubview:label];
    
    return view;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == 0)
    {
        if (indexPath.row == 0)
        {
            [self performSegueWithIdentifier:@"SelectRestaurant" sender:self];
        }
    }
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([segue.identifier isEqualToString:@"SelectRestaurant"])
    {
        FOMRestaurantSelectionViewController *destinationViewController = segue.destinationViewController;
        destinationViewController.selectedRestaurant = self.order.restaurant;
        destinationViewController.delegate = self;
    }
}

- (void)restaurantHasChanged:(FOMRestaurant *)restaurant
{
    self.order.restaurant = restaurant;
}

@end
