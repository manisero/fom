//
//  FOMOrderItem.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FOMOrderItem : NSObject

@property (nonatomic, strong) NSString *dish;
@property (nonatomic, strong) NSNumber *dishId;
@property (nonatomic, strong) NSNumber *quantity;

@end
