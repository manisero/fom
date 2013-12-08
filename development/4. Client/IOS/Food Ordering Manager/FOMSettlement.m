//
//  FOMSettlement.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMSettlement.h"

@implementation FOMSettlement

+ (FOMSettlement *)settlementFor:(NSString *)personName withAmountToSettle:(NSNumber *)toSettle
{
    FOMSettlement *settlement = [[FOMSettlement alloc] init];
    settlement.name = personName;
    settlement.toSettle = toSettle;
    
    return settlement;
}

@end
