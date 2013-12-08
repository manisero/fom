//
//  FOMOrderDetailsViewController.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FOMCommunicationHandlerDelegate.h"
#import "FOMLoadingDialog.h"
#import "FOMOrder.h"

@interface FOMOrderDetailsViewController : UIViewController<UITableViewDataSource, UITableViewDelegate, FOMCommunicationHandlerDelegate>

@property (nonatomic, strong) IBOutlet UITableView *tableView;
@property (nonatomic, strong) FOMLoadingDialog *loadingDialog;
@property (nonatomic, strong) FOMOrder *order;
@property (nonatomic, strong) NSArray *settlements;

- (IBAction)addOrderItemsButtonPushed:(id)sender;

@end
