//
//  FOMDish.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 08.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMDish : NSObject

@property (nonatomic, strong) NSNumber *identifier;
@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSNumber *price;

+ (FOMDish *)dishWithIdentifier:(NSNumber *)identifier name:(NSString *)name andPrice:(NSNumber *)price;

@end
