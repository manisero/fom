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
+ (NSString *)ordersServiceAddress;

@end
