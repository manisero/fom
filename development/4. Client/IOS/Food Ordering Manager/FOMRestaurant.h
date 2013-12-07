//
//  FOMRestaurant.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMRestaurant : NSObject

@property (nonatomic, strong) NSNumber *identifier;
@property (nonatomic, strong) NSString *name;

+ (FOMRestaurant *)restaurantWithName:(NSString *)name andIdentifier:(NSNumber *)identifier;

@end
