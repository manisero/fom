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

- (void)startGetConnectionWithAddress:(NSString *)address
{
    [self startConnectionWithAddress:address andMethod:@"GET" andBody:nil];
}

- (void)startPostConnectionWithAddress:(NSString *)address andBody:(NSData *)body
{
    [self startConnectionWithAddress:address andMethod:@"POST" andBody:body];
}

- (void)startPutConnectionWithAddress:(NSString *)address andBody:(NSData *)body
{
    [self startConnectionWithAddress:address andMethod:@"PUT" andBody:body];
}

- (void)startConnectionWithAddress:(NSString *)address andMethod:(NSString *)method andBody:(NSData *)body
{
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:[NSURL URLWithString:address]];
    [request setHTTPMethod:method];
    [request setValue:@"application/json" forHTTPHeaderField:@"Accept"];
    [request setValue:@"application/json" forHTTPHeaderField:@"Content-Type"];
    
    if (body != nil)
    {
        [request setHTTPBody:body];
    }
    
    self.address = address;
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
    if (self.delegate != nil)
    {
        NSLog(@"response: %@", [[NSString alloc] initWithData:self.data encoding:NSUTF8StringEncoding]);
        [self.delegate communicationForAddress:self.address finishedSuccessfullyWithResponse:self.data];
    }
}

- (void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error
{
    if (self.delegate != nil)
    {
        [self.delegate communicationForAddress:self.address failedWithError:error];
    }
}

@end
