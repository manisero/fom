//
//  FOMOrderItemsSelectionViewController.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FOMCommunicationHandlerDelegate.h"
#import "FOMDishDataDelegate.h"
#import "FOMOrder.h"

@interface FOMOrderItemsSelectionViewController : UIViewController<UITableViewDataSource, UITableViewDelegate, FOMDishDataDelegate, FOMCommunicationHandlerDelegate, UIAlertViewDelegate>

@property (nonatomic, strong) IBOutlet UITableView *tableView;
@property (nonatomic, strong) FOMLoadingDialog *sendingDialog;
@property (nonatomic, strong) FOMOrder *order;

- (IBAction)addItemButtonClicked:(id)sender;

@end
