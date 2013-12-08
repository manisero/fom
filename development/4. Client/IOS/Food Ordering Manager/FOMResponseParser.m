//
//  FOMResponseParser.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMDish.h"
#import "FOMOrder.h"
#import "FOMResponseParser.h"
#import "FOMRestaurant.h"
#import "FOMSettlement.h"

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

+ (NSArray *)parseOrdersFromResponse:(NSData *)response
{
    NSMutableArray *orders = [[NSMutableArray alloc] init];
    NSDictionary *jsonResponse = [self dictionaryFromResponse:response];
    
    for (NSDictionary *order in jsonResponse)
    {
        NSString *deliveryDate = [order objectForKey:@"DeliveryDate"];
        NSString *intendedDeliveryTime = [order objectForKey:@"IntendedDeliveryTime"];
        NSNumber *orderId = [order objectForKey:@"OrderID"];
        NSString *restaurantName = [order objectForKey:@"RestaurantName"];
        NSNumber *restaurantId = [order objectForKey:@"RestaurantID"];
        NSString *owner = [[order objectForKey:@"Owner"] objectForKey:@"Name"];
        NSString *status = [order objectForKey:@"Status"];
        
        FOMRestaurant *restaurant = [FOMRestaurant restaurantWithName:restaurantName andIdentifier:restaurantId];
        FOMOrder *order = [FOMOrder orderWithName:restaurantName deliveryDate:[FOMResponseParser parseDeliveryDate:deliveryDate andDeliveryTime:intendedDeliveryTime] restaurant:restaurant orderer:owner status:status andIdentifier:orderId];
        
        [orders addObject:order];
    }
    
    return orders;
}

+ (NSDate *)parseDeliveryDate:(NSString *)deliveryDate andDeliveryTime:(NSString *)deliveryTime
{
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:@"yyyy-MM-dd HH:mm:ss"];
    
    return [formatter dateFromString:[NSString stringWithFormat:@"%@ %@", deliveryDate, deliveryTime]];
}

+ (NSArray *)parseSettlementsFromResponse:(NSData *)response
{
    NSMutableArray *settlements = [[NSMutableArray alloc] init];
    NSDictionary *jsonResponse = [self dictionaryFromResponse:response];
    
    for (NSDictionary *settlement in jsonResponse)
    {
        NSString *name = [[settlement objectForKey:@"Person"] objectForKey:@"Name"];
        NSNumber *toSettle = [settlement objectForKey:@"Amount"];
        
        FOMSettlement *settlement = [FOMSettlement settlementFor:name withAmountToSettle:toSettle];
        [settlements addObject:settlement];
    }
    
    return settlements;
}

@end
