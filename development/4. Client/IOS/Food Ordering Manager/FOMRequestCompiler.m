//
//  FOMRequestCompiler.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMOrder.h"
#import "FOMRequestCompiler.h"

@implementation FOMRequestCompiler

+ (NSData *)createRequestBodyForOrder:(FOMOrder *)order
{
    NSDictionary *orderRequestBody = [NSDictionary dictionaryWithObjectsAndKeys:
                                      order.restaurant.identifier, @"RestaurantID",
                                      [FOMRequestCompiler date:order.date AsStringWithFormat:@"yyyy-MM-dd"], @"DeliveryDate",
                                      [FOMRequestCompiler date:order.date AsStringWithFormat:@"HH:mm:ss"], @"IntendedDeliveryTime",
                                      nil];
    
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:orderRequestBody options:NSJSONWritingPrettyPrinted error:nil];
    return jsonData;
}

+ (NSString *)date:(NSDate *)date AsStringWithFormat:(NSString *)dateFormat
{
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:dateFormat];
    
    return [formatter stringFromDate:date];
}

@end
