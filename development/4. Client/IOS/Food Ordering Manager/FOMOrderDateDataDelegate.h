//
//  FOMOrderDateDataDelegate.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol FOMOrderDateDataDelegate <NSObject>

- (void)orderDateHasChanged:(NSDate *)date;

@end
