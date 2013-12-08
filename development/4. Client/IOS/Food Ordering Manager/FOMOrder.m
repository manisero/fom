//
//  FOMOrder.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMOrder.h"

@implementation FOMOrder

- (id)init
{
    self = [super init];
    
    if (self != nil)
    {
        self.items = [[NSArray alloc] init];
    }
    
    return self;
}

+ (FOMOrder *)orderWithName:(NSString *)name deliveryDate:(NSDate *)date restaurant:(FOMRestaurant *)restaurant orderer:(NSString *)orderer status:(NSString *)status andIdentifier:(NSNumber *)orderId
{
    FOMOrder *order = [[FOMOrder alloc] init];
    order.name = name;
    order.date = date;
    order.restaurant = restaurant;
    order.orderer = orderer;
    order.orderId = orderId;
    order.status = status;
    
    return order;
}

@end
