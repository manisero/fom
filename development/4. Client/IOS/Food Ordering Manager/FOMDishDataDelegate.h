//
//  FOMDishDataDelegate.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "FOMDish.h"

@protocol FOMDishDataDelegate <NSObject>

- (void)dishHasChanged:(FOMDish *)dish;

@end
