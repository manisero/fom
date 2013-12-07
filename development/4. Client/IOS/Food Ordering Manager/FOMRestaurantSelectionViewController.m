//
//  FOMRestaurantSelectionViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMCommunicationHandler.h"
#import "FOMConfigurationProvider.h"
#import "FOMRestaurant.h"
#import "FOMRestaurantSelectionViewController.h"

@interface FOMRestaurantSelectionViewController ()

@end

@implementation FOMRestaurantSelectionViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self fetchRestaurants];
    [[[FOMCommunicationHandler alloc] init] startConnection:[FOMConfigurationProvider restaurantsServiceAddress]];
}

- (void)fetchRestaurants
{
    FOMRestaurant *firstRestaurant = [FOMRestaurant restaurantWithName:@"Restauracja #1" andIdentifier:[NSNumber numberWithInt:1]];
    FOMRestaurant *secondRestaurant = [FOMRestaurant restaurantWithName:@"Restauracja #2" andIdentifier:[NSNumber numberWithInt:2]];
    
    self.restaurants = [[NSArray alloc] initWithObjects:firstRestaurant, secondRestaurant, nil];
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
    return 1;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:@"TableCell"];
    self.pickerView = (UIPickerView *)[cell.contentView viewWithTag:111];
    return cell;
}

- (NSInteger)pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    return [self.restaurants count];
}

- (NSInteger)numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return 1;
}

- (NSString *)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    FOMRestaurant *restaurant = [self.restaurants objectAtIndex:row];
    return restaurant.name;
}

- (void)pickerView:(UIPickerView *)pickerView didSelectRow:(NSInteger)row inComponent:(NSInteger)component
{
    self.selectedRestaurant = [self.restaurants objectAtIndex:row];
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section
{
    CGRect headerFrame = CGRectMake(0.0, 0.0, self.view.frame.size.width, 44.0);
    
    UIView *view = [[UIView alloc] initWithFrame:headerFrame];
    
    UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(10.0, headerFrame.origin.y, headerFrame.size.width, headerFrame.size.height)];
    label.font = [UIFont boldSystemFontOfSize:17.0];
    label.text = NSLocalizedString(@"Restaurant Choice", nil);
    
    [view addSubview:label];
    
    return view;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section
{
    return 44.0;
}

- (IBAction)saveButtonPressed:(id)sender
{
    if (self.delegate != nil && self.selectedRestaurant != nil)
    {
        [self.delegate restaurantHasChanged:self.selectedRestaurant];
    }
    
    [self.navigationController popViewControllerAnimated:YES];
}

@end
