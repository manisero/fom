//
//  FOMConfigurationProvider.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMConfigurationProvider.h"

@implementation FOMConfigurationProvider

+ (NSDictionary *)defaultSettings
{
    NSString *defaultSettingsPath = [[NSBundle mainBundle] pathForResource:@"DefaultConfiguration" ofType:@"plist"];
    return [[NSDictionary alloc] initWithContentsOfFile:defaultSettingsPath];
}

+ (NSString *)defaultServiceAddress
{
    return [[self defaultSettings] valueForKey:@"serviceAddress"];
}

+ (NSString *)defaultUserEmailAddress
{
    return [[self defaultSettings] valueForKey:@"userEmailAddress"];
}

+ (NSString *)restaurantsServiceAddress
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@", serviceAddress, @"api/restaurants"];
    
    return serviceAddress;
}

+ (NSString *)ordersServiceAddress
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@", serviceAddress, @"api/orders"];
    
    return serviceAddress;
}

+ (NSString *)createOrdersServiceAddress
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@%@%@", serviceAddress, @"api/users/", [FOMConfigurationProvider userEmailAddress], @"/orders"];
    
    return serviceAddress;
}

+ (NSString *)dishesServiceAddress:(NSNumber *)restaurantId
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@%@%@", serviceAddress, @"api/restaurants/", restaurantId, @"/dishes"];
    
    return serviceAddress;
}

+ (NSString *)orderItemsServiceAddress:(NSNumber *)orderId
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@%@%@", serviceAddress, @"api/orders/", orderId, @"/items"];
    
    return serviceAddress;
}

+ (NSString *)createOrderItemsServiceAddress:(NSNumber *)orderId
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@%@%@%@%@", serviceAddress, @"api/users/", [FOMConfigurationProvider userEmailAddress], @"/orders/", orderId, @"/items"];
    
    return serviceAddress;
}

+ (NSString *)userEmailAddress
{
    NSString *userEmailAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"userEmailAddress"];
    userEmailAddress = userEmailAddress != nil ? userEmailAddress : [self defaultUserEmailAddress];
    
    return userEmailAddress;
}

@end
