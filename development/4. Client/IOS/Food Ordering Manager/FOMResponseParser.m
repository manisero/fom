//
//  FOMResponseParser.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

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

@end
