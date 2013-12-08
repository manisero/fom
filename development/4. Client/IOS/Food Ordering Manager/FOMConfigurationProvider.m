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

+ (NSString *)restaurantsServiceAddress
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : [self defaultServiceAddress];
    serviceAddress = [NSString stringWithFormat:@"%@%@", serviceAddress, @"api/restaurants"];
    
    return serviceAddress;
}

@end
