//
//  FOMCommunicationHandler.m
//  Food Ordering Manager
//
//  Created by Jakub Turek on 07.12.2013.
//  Copyright (c) 2013 Jakub Turek. All rights reserved.
//

#import "FOMCommunicationHandler.h"

@implementation FOMCommunicationHandler

- (id)init
{
    self = [super init];
    
    if (self != nil)
    {
        self.data = [[NSMutableData alloc] init];
    }
    
    return self;
}

- (void)startConnection:(NSString *)address
{
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:[NSURL URLWithString:address]];
    [request setHTTPMethod:@"GET"];
    [request setValue:@"application/json" forHTTPHeaderField:@"Accept"];
    
    self.connection = [[NSURLConnection alloc] initWithRequest:request delegate:self];
}

- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response
{
    [self.data setLength: 0];
}

- (void)connection:(NSURLConnection *)connection didReceiveData:(NSData *)data
{
    [self.data appendData:data];
}

- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
    NSString *response = [[NSString alloc] initWithData:self.data encoding:NSUTF8StringEncoding];
    
    NSLog(@"response: %@", response);
}

@end
