//
//  FOMRestaurant.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMRestaurant.h"

@implementation FOMRestaurant

+ (FOMRestaurant *)restaurantWithName:(NSString *)name andIdentifier:(NSNumber *)identifier
{
    FOMRestaurant *restaurant = [[FOMRestaurant alloc] init];
    restaurant.name = name;
    restaurant.identifier = identifier;
        
    return restaurant;
}

@end
