//
//  FOMNewOrderViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMDateSelectionViewController.h"
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
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return 2;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:@"RightDetailCell"];
    cell.textLabel.text = NSLocalizedString(indexPath.row == 0 ? @"Restaurant Name" : @"Order Date", nil);
        
    if (indexPath.row == 0)
    {
        cell.detailTextLabel.text = self.order.restaurant != nil ? self.order.restaurant.name : NSLocalizedString(@"Choose", nil);
    }
    else if (indexPath.row == 1)
    {
        cell.detailTextLabel.text = self.order.date != nil ? [self formatDate:self.order.date] : NSLocalizedString(@"Choose", nil);
    }
    
    return cell;
}

- (NSString *)formatDate:(NSDate *)date
{
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    formatter.dateFormat = @"HH:mm";
    
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
    label.text = NSLocalizedString(@"Order Details", nil);
    
    [view addSubview:label];
    
    return view;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.row == 0)
    {
        [self performSegueWithIdentifier:@"SelectRestaurant" sender:self];
    }
    else if (indexPath.row == 1)
    {
        [self performSegueWithIdentifier:@"SelectDate" sender:self];
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
    else if ([segue.identifier isEqualToString:@"SelectDate"])
    {
        FOMDateSelectionViewController *destinationViewController = segue.destinationViewController;
        destinationViewController.delegate = self;
    }
}

- (void)restaurantHasChanged:(FOMRestaurant *)restaurant
{
    self.order.restaurant = restaurant;
}

- (void)orderDateHasChanged:(NSDate *)date
{
    self.order.date = date;
}

@end
