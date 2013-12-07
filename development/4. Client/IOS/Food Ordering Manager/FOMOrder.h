//
//  FOMOrder.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMOrder : NSObject

@property (nonatomic, strong) NSString *name;

+ (FOMOrder *)orderWithName:(NSString *)name;

@end
