//
//  FOMResponseParser.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMDish.h"
#import "FOMResponseParser.h"
#import "FOMRestaurant.h"

@implementation FOMResponseParser

+ (NSArray *)parseRestaurantsFromResponse:(NSData *)response
{
    NSMutableArray *restaurants = [[NSMutableArray alloc] init];
    NSDictionary *jsonResponse = [self dictionaryFromResponse:response];
    
    for (NSDictionary *restaurant in jsonResponse)
    {
        NSString *name = [restaurant valueForKey:@"Name"];
        NSNumber *restaurantId = [restaurant valueForKey:@"RestaurantID"];
        
        FOMRestaurant *restaurant = [FOMRestaurant restaurantWithName:name andIdentifier:restaurantId];
        [restaurants addObject:restaurant];
    }
    
    return restaurants;
}

+ (NSDictionary *)dictionaryFromResponse:(NSData *)response
{
    NSError *localError = nil;
    NSDictionary *parsedResponse = [NSJSONSerialization JSONObjectWithData:response options:0 error:&localError];
    
    if (localError != nil)
    {
        [NSException raise:@"Invalid JSON Exception" format:@"%@", [localError description]];
    }
    
    return parsedResponse;
}

+ (NSNumber *)parseOrderIdFromResponse:(NSData *)response
{
    NSDictionary *jsonResponse = [self dictionaryFromResponse:response];
    return [jsonResponse valueForKey:@"OrderID"];
}

+ (NSArray *)parseDishesFromResponse:(NSData *)response
{
    NSMutableArray *dishes = [[NSMutableArray alloc] init];
    NSDictionary *jsonResponse = [self dictionaryFromResponse:response];
    
    for (NSDictionary *dish in jsonResponse)
    {
        NSString *name = [dish valueForKey:@"Name"];
        NSNumber *dishId = [dish valueForKey:@"DishID"];
        NSNumber *price = [dish valueForKey:@"Price"];
        
        FOMDish *dish = [FOMDish dishWithIdentifier:dishId name:name andPrice:price];
        [dishes addObject:dish];
    }
    
    return dishes;
}

@end
