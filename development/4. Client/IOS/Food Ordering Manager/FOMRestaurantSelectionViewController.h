//
//  FOMRestaurantSelectionViewController.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FOMCommunicationHandlerDelegate.h"
#import "FOMLoadingDialog.h"
#import "FOMRestaurantDataDelegate.h"

@interface FOMRestaurantSelectionViewController : UIViewController<UITableViewDataSource, UITableViewDelegate, UIPickerViewDataSource, UIPickerViewDelegate, FOMCommunicationHandlerDelegate>

@property (nonatomic, strong) id<FOMRestaurantDataDelegate> delegate;
@property (nonatomic, strong) FOMRestaurant *selectedRestaurant;

@property (nonatomic, strong) IBOutlet UITableView *tableView;
@property (nonatomic, strong) IBOutlet UIPickerView *pickerView;
@property (nonatomic, strong) FOMLoadingDialog *loadingDialog;
@property (nonatomic, strong) NSArray *restaurants;

- (IBAction)saveButtonPressed:(id)sender;

@end
