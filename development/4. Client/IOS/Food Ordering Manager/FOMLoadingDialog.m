//
//  FOMLoadingDialog.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <QuartzCore/QuartzCore.h>
#import "FOMLoadingDialog.h"

@implementation FOMLoadingDialog

- (id)initWithFrame:(CGRect)frame
{
    self = [super initWithFrame:frame];
    
    [self configureLoadingBox];
    [self configureLoadingIndicator];
    [self configureLoadingLabel];
    [self configureVisibility];
    
    return self;
}

- (void)configureLoadingBox
{
    self.loadingBox = [[UIView alloc] initWithFrame:CGRectMake(0.0, 0.0, 150.0f, 150.0f)];
    self.loadingBox.backgroundColor = [UIColor colorWithRed:0.0 green:0.0 blue:0.0 alpha:0.5];
    self.loadingBox.layer.cornerRadius = 10.0f;
    self.loadingBox.center = self.center;
    
    [self addSubview:self.loadingBox];
}

- (void)configureLoadingIndicator
{
    self.loadingIndicator = [[UIActivityIndicatorView alloc] initWithActivityIndicatorStyle:UIActivityIndicatorViewStyleWhiteLarge];
    self.loadingIndicator.center = CGPointMake(self.loadingBox.center.x, self.loadingBox.center.y - 10.0f);
    
    [self addSubview:self.loadingIndicator];
}

- (void)configureLoadingLabel
{
    self.loadingLabel = [[UILabel alloc] initWithFrame:CGRectMake(0.0f, 0.0f, 150.0f, 25.0f)];
    self.loadingLabel.text = NSLocalizedString(@"Loading", nil);
    self.loadingLabel.textColor = [UIColor whiteColor];
    self.loadingLabel.center = CGPointMake(self.loadingBox.center.x, self.loadingBox.center.y + 35.0f);
    self.loadingLabel.font = [UIFont systemFontOfSize:14.0];
    self.loadingLabel.textAlignment = NSTextAlignmentCenter;
    
    [self addSubview:self.loadingLabel];
}

- (void)configureVisibility
{
    [self setHidden:YES];
}

- (void)startAnimating
{
    [[UIApplication sharedApplication] beginIgnoringInteractionEvents];
    [self.loadingIndicator startAnimating];
    [self setHidden:NO];
}

- (void)stopAnimating
{
    [self setHidden:YES];
    [self.loadingIndicator stopAnimating];
    [[UIApplication sharedApplication] endIgnoringInteractionEvents];
}

@end
