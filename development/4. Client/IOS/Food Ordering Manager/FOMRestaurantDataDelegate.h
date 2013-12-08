//
//  FOMRestaurantDataDelegate.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "FOMRestaurant.h"

@protocol FOMRestaurantDataDelegate <NSObject>

- (void)restaurantHasChanged:(FOMRestaurant *)restaurant;

@end
