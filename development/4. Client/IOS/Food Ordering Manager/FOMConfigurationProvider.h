//
//  FOMConfigurationProvider.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMConfigurationProvider : NSObject

+ (NSString *)restaurantsServiceAddress;
+ (NSString *)ordersServiceAddressForStatus:(NSString *)status;
+ (NSString *)dishesServiceAddress:(NSNumber *)restaurantId;
+ (NSString *)orderItemsServiceAddress:(NSNumber *)orderId;
+ (NSString *)createOrdersServiceAddress;
+ (NSString *)createOrderItemsServiceAddress:(NSNumber *)orderId;
+ (NSString *)settlementServiceAddress:(NSNumber *)orderId;
+ (NSString *)myOrdersServiceAddress;

@end
