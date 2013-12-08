//
//  FOMNewOrderViewController.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FOMCommunicationHandlerDelegate.h"
#import "FOMLoadingDialog.h"
#import "FOMOrder.h"
#import "FOMOrderDateDataDelegate.h"
#import "FOMRestaurantDataDelegate.h"

@interface FOMNewOrderViewController : UIViewController<UITableViewDataSource, UITableViewDelegate, FOMRestaurantDataDelegate, FOMOrderDateDataDelegate, FOMCommunicationHandlerDelegate, UIAlertViewDelegate>

@property (nonatomic, strong) FOMLoadingDialog *creatingOrderDialog;
@property (nonatomic, strong) IBOutlet UITableView *tableView;

@property (nonatomic, strong) FOMOrder *order;

- (IBAction)createButtonPressed:(id)sender;

@end
