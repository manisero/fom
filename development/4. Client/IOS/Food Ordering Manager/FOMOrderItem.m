//
//  FOMOrderItem.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMOrderItem.h"

@implementation FOMOrderItem

- (id)init
{
    self = [super init];
    
    if (self != nil)
    {
        self.quantity = [[NSNumber alloc] initWithInt:0];
    }
    
    return self;
}

@end
