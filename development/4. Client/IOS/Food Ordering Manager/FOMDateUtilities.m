//
//  FOMDateUtilities.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMDateUtilities.h"

@implementation FOMDateUtilities

+ (NSString *)dateToString:(NSDate *)date
{
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:@"yyyy-MM-dd HH:mm"];
    
    return [formatter stringFromDate:date];
}

@end
