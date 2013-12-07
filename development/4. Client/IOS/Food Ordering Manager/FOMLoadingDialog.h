//
//  FOMLoadingDialog.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface FOMLoadingDialog : UIView

@property (nonatomic, strong) UIView *loadingBox;
@property (nonatomic, strong) UIActivityIndicatorView *loadingIndicator;
@property (nonatomic, strong) UILabel *loadingLabel;

@end
