//
//  FOMOrder.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMOrder.h"

@implementation FOMOrder

+ (FOMOrder *)orderWithName:(NSString *)name
{
    FOMOrder *order = [[FOMOrder alloc] init];
    order.name = name;
    
    return order;
}

@end
