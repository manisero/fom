//
//  FOMOrderItemDetailsViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMCommunicationHandler.h"
#import "FOMConfigurationProvider.h"
#import "FOMLoadingDialog.h"
#import "FOMOrderItemDetailsViewController.h"
#import "FOMResponseParser.h"

@interface FOMOrderItemDetailsViewController ()

@end

@implementation FOMOrderItemDetailsViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
}

- (void)viewDidAppear:(BOOL)animated
{
    [self fetchDishes];
}

- (void)fetchDishes
{
    self.dishes = [[NSArray alloc] init];
    [self showLoadingDialog];
    [self invokeCommunication];
}

- (void)showLoadingDialog
{
    self.loadingDialog = [[FOMLoadingDialog alloc] initWithFrame:self.view.frame];
    [self.view addSubview:self.loadingDialog];
    [self.loadingDialog startAnimating];
}

- (void)invokeCommunication
{
    FOMCommunicationHandler *communicationHandler = [[FOMCommunicationHandler alloc] init];
    [communicationHandler setDelegate:self];
    [communicationHandler startGetConnectionWithAddress:[FOMConfigurationProvider dishesServiceAddress:self.restaurantId]];
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
    return 1;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSString *identifier = indexPath.section == 0 ? @"PriceCell" : @"DishCell";
    
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:identifier];
    
    if (indexPath.section == 0)
    {
        self.priceLabel = cell.detailTextLabel;
    }
    else if (indexPath.section == 1)
    {
        self.pickerView = (UIPickerView *)[cell.contentView viewWithTag:111];
        self.pickerView.delegate = self;
        self.pickerView.dataSource = self;
    }
    
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == 1)
    {
        return 162.0f;
    }
    
    return 44.0f;
}

- (NSInteger)pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    return [self.dishes count];
}

- (NSInteger)numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return 1;
}

- (NSString *)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    FOMDish *dish = [self.dishes objectAtIndex:row];
    return dish.name;
}

- (void)pickerView:(UIPickerView *)pickerView didSelectRow:(NSInteger)row inComponent:(NSInteger)component
{
    self.selectedDish = [self.dishes objectAtIndex:row];
    self.priceLabel.text = [NSString stringWithFormat:@"%.02f zł", [self.selectedDish.price doubleValue]];
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section
{
    CGRect headerFrame = CGRectMake(0.0, 0.0, self.view.frame.size.width, 44.0);
    
    UIView *view = [[UIView alloc] initWithFrame:headerFrame];
    
    UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(10.0, headerFrame.origin.y, headerFrame.size.width, headerFrame.size.height)];
    label.font = [UIFont boldSystemFontOfSize:17.0];
    label.text = NSLocalizedString(section == 0 ? @"Price Details" : @"Dish Choice", nil);
    
    [view addSubview:label];
    
    return view;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section
{
    return 44.0;
}

- (IBAction)saveButtonPressed:(id)sender
{
    if (self.delegate != nil && self.selectedDish != nil)
    {
        [self.delegate dishHasChanged:self.selectedDish];
    }
    
    [self.navigationController popViewControllerAnimated:YES];
}

- (void)communicationForAddress:(NSString *)address finishedSuccessfullyWithResponse:(NSData *)sentData
{
    [self addFetchedDishes:[FOMResponseParser parseDishesFromResponse:sentData]];
    [self hideLoadingDialog];
}

- (void)addFetchedDishes:(NSArray *)dishes
{
    self.dishes = dishes;
    [self.pickerView reloadAllComponents];
    
    if ([self.dishes count] > 0)
    {
        self.selectedDish = [dishes objectAtIndex:0];
        self.priceLabel.text = [NSString stringWithFormat:@"%.02f zł", [self.selectedDish.price doubleValue]];
    }
}

- (void)hideLoadingDialog
{
    [self.loadingDialog stopAnimating];
    [self.loadingDialog removeFromSuperview];
}

- (void)communicationForAddress:(NSString *)address failedWithError:(NSError *)error
{
    [self hideLoadingDialog];
}

@end
