//
//  FOMOrderItemDetailsViewController.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FOMCommunicationHandlerDelegate.h"
#import "FOMDish.h"
#import "FOMDishDataDelegate.h"
#import "FOMLoadingDialog.h"

@interface FOMOrderItemDetailsViewController : UIViewController<UITableViewDelegate, UITableViewDataSource, UIPickerViewDataSource, UIPickerViewDelegate, FOMCommunicationHandlerDelegate>

@property id<FOMDishDataDelegate> delegate;

@property (nonatomic, strong) IBOutlet UITableView *tableView;
@property (nonatomic, strong) IBOutlet UIPickerView *pickerView;
@property (nonatomic, strong) IBOutlet UILabel *priceLabel;
@property (nonatomic, strong) FOMLoadingDialog *loadingDialog;

@property (nonatomic, strong) NSNumber *restaurantId;
@property (nonatomic, strong) NSArray *dishes;
@property (nonatomic, strong) FOMDish *selectedDish;

@end
