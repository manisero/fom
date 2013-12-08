//
//  FOMViewController.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FOMCommunicationHandlerDelegate.h"
#import "FOMLoadingDialog.h"
#import "FOMOrder.h"

@interface FOMRootViewController : UIViewController<UITableViewDelegate, UITableViewDataSource, FOMCommunicationHandlerDelegate>

@property (nonatomic, strong) IBOutlet UITableView *tableView;
@property (nonatomic, strong) FOMLoadingDialog *loadingDialog;
@property (nonatomic, strong) FOMOrder *selectedOrder;
@property (nonatomic, strong) NSArray *orders;

@end
