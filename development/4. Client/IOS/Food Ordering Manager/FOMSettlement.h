//
//  FOMSettlement.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMSettlement : NSObject

@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSNumber *toSettle;

+ (FOMSettlement *)settlementFor:(NSString *)personName withAmountToSettle:(NSNumber *)toSettle;

@end
