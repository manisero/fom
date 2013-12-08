//
//  FOMOrder.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "FOMRestaurant.h"

@interface FOMOrder : NSObject

@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) FOMRestaurant *restaurant;
@property (nonatomic, strong) NSDate *date;
@property (nonatomic, strong) NSArray *items;
@property (nonatomic, strong) NSNumber *orderId;

+ (FOMOrder *)orderWithName:(NSString *)name deliveryDate:(NSDate *)date restaurant:(FOMRestaurant *)restaurant andIdentifier:(NSNumber *)orderId;

@end
