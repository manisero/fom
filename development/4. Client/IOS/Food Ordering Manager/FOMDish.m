//
//  FOMDish.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMDish.h"

@implementation FOMDish

+ (FOMDish *)dishWithIdentifier:(NSNumber *)identifier name:(NSString *)name andPrice:(NSNumber *)price
{
    FOMDish *dish = [[FOMDish alloc] init];
    dish.identifier = identifier;
    dish.name = name;
    dish.price = price;
    
    return dish;
}

@end
