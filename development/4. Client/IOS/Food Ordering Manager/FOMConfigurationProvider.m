//
//  FOMConfigurationProvider.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMConfigurationProvider.h"

@implementation FOMConfigurationProvider

+ (NSString *)restaurantsServiceAddress
{
    NSString *serviceAddress = [[NSUserDefaults standardUserDefaults] valueForKey:@"serviceAddress"];
    serviceAddress = serviceAddress != nil ? serviceAddress : @"http://192.168.1.147:8080/api/restaurant";
    
    return serviceAddress;
}

@end
