//
//  FOMOrderItemsSelectionViewController.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMCommunicationHandler.h"
#import "FOMConfigurationProvider.h"
#import "FOMOrderItemDetailsViewController.h"
#import "FOMOrderItemsSelectionViewController.h"
#import "FOMRequestCompiler.h"

@interface FOMOrderItemsSelectionViewController ()

@end

@implementation FOMOrderItemsSelectionViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self clearItems];
}

- (void)clearItems
{
    self.order.items = [[NSArray alloc] init];
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
    return section == 0 ? [self.order.items count] : 1;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSString *identifier = indexPath.section == 0 ? @"TableCell" : @"SendCell";
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:identifier];
    
    if (indexPath.section == 0)
    {
        FOMDish *dish = [self.order.items objectAtIndex:indexPath.row];
        
        if (cell != nil && dish != nil)
        {
            cell.textLabel.text = dish.name;
            cell.detailTextLabel.text = [NSString stringWithFormat:@"%.02f zł", [dish.price doubleValue]];
        }
    }
    else if (indexPath.section == 1)
    {
        cell.textLabel.text = NSLocalizedString(@"Send", nil);
    }
    
    return cell;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section
{
    CGRect headerFrame = CGRectMake(0.0, 0.0, self.view.frame.size.width, 44.0);
    
    UIView *view = [[UIView alloc] initWithFrame:headerFrame];
    
    UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(10.0, headerFrame.origin.y, headerFrame.size.width, headerFrame.size.height)];
    label.font = [UIFont boldSystemFontOfSize:17.0];
    label.text = NSLocalizedString(@"Order Entries", nil);
    
    [view addSubview:label];
    
    return view;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section
{
    return 44.0;
}

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath
{
    return indexPath.section == 0;
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (editingStyle == UITableViewCellEditingStyleDelete)
    {
        NSMutableArray *items = [[NSMutableArray alloc] initWithArray:self.order.items];
        [items removeObjectAtIndex:indexPath.row];
        
        [self.order setItems:items];
        [self.tableView reloadData];
    }
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == 1)
    {
        [self showSendingDialog];
        [self invokeOrderItemsCreation];
    }
}

- (void)showSendingDialog
{
    self.sendingDialog = [[FOMLoadingDialog alloc] initWithFrame:self.view.frame];
    [self.sendingDialog.loadingLabel setText:NSLocalizedString(@"Send In Progress", nil)];
    [self.view addSubview:self.sendingDialog];
    [self.sendingDialog startAnimating];
}

- (void)invokeOrderItemsCreation
{
    NSData *orderItems = [FOMRequestCompiler createRequestBodyForOrderItems:self.order];
    
    FOMCommunicationHandler *communicationHandler = [[FOMCommunicationHandler alloc] init];
    [communicationHandler setDelegate:self];
    [communicationHandler startPutConnectionWithAddress:[FOMConfigurationProvider createOrderItemsServiceAddress:self.order.orderId] andBody:orderItems];
}

- (IBAction)addItemButtonClicked:(id)sender
{
    [self performSegueWithIdentifier:@"OrderItemDetails" sender:self];
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([segue.identifier isEqualToString:@"OrderItemDetails"])
    {
        FOMOrderItemDetailsViewController *destinationViewController = segue.destinationViewController;
        destinationViewController.restaurantId = self.order.restaurant.identifier;
        destinationViewController.delegate = self;
    }
}

- (void)dishHasChanged:(FOMDish *)dish
{
    NSMutableArray *dishes = [[NSMutableArray alloc] initWithArray:self.order.items];
    [dishes addObject:dish];
    
    [self.order setItems:dishes];
    [self.tableView reloadData];
}

- (void)communicationFinishedSuccessfully:(NSData *)sentData
{
    [self hideSendingDialog];
    [self testResponseShouldBeEmpty:sentData];
}

- (void)testResponseShouldBeEmpty:(NSData *)response
{
    NSString *responseAsText = [[NSString alloc] initWithData:response encoding:NSUTF8StringEncoding];
    
    if (response == nil || [[responseAsText stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]] length] == 0)
    {
        [self showSuccessDialog];
    }
    else
    {
        [self showFailureDialog];
    }
}

- (void)hideSendingDialog
{
    [self.sendingDialog stopAnimating];
    [self.sendingDialog removeFromSuperview];
}

- (void)showSuccessDialog
{
    UIAlertView *alert = [[UIAlertView alloc]
                          initWithTitle:NSLocalizedString(@"Sent", nil)
                          message:NSLocalizedString(@"Thank You For Ordering", nil)
                          delegate:self
                          cancelButtonTitle:NSLocalizedString(@"OK", nil)
                          otherButtonTitles:nil];
    
    [alert show];
}

- (void)communicationFailedWithError:(NSError *)error
{
    [self hideSendingDialog];
    [self showFailureDialog];
}

- (void)showFailureDialog
{
    UIAlertView *alert = [[UIAlertView alloc]
                          initWithTitle:NSLocalizedString(@"Error", nil)
                          message:NSLocalizedString(@"Ordering Failed", nil)
                          delegate:self
                          cancelButtonTitle:NSLocalizedString(@"OK", nil)
                          otherButtonTitles:nil];
    
    [alert show];
}

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex
{
    if ([alertView.title isEqualToString:NSLocalizedString(@"Sent", nil)])
    {
        [self.navigationController popToRootViewControllerAnimated:YES];
    }
}

@end
