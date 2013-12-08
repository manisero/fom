//
//  FOMCommunicationHandler.h
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "FOMCommunicationHandlerDelegate.h"

@interface FOMCommunicationHandler : NSObject<NSURLConnectionDataDelegate, NSURLConnectionDelegate>

@property id<FOMCommunicationHandlerDelegate> delegate;

@property (nonatomic, strong) NSURLConnection *connection;
@property (nonatomic, strong) NSMutableData *data;

- (void)startConnection:(NSString *)address;

@end
