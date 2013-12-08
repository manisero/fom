//
//  FOMRequestCompiler.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMRequestCompiler : NSObject

+ (NSData *)createRequestBodyForOrder:(FOMOrder *)order;
+ (NSString *)date:(NSDate *)date AsStringWithFormat:(NSString *)dateFormat;

@end
