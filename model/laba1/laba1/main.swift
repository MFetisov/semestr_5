//
//  main.swift
//  laba1
//
//  Created by Ибрагим Мамадаев on 24.09.2018.
//  Copyright © 2018 Ибрагим Мамадаев. All rights reserved.
//
import Foundation

print("Hello, World!")
var randomInt = Int.random(in: 0..<10000)
print(randomInt)
//var numbers: [Double] = [0.5, 0.2, 0.3]
var StartStatus: [Double] = [0.500, 0.200, 0.300]
var StatusMatrix = [[0.600, 0.200, 0.200],
                    [0.300, 0.300, 0.400],
                    [0.100, 0.700, 0.200]]
var State1 = 0, State2 = 0, State3 = 0, CurrStatus = -1, random: Double
for _ in 0...100{
    random = Double.random(in: 0.000...100.000)
    if (random > (StartStatus[0] + StartStatus[1])){
        CurrStatus = 2;
    }
    else{
        if (random < StartStatus[0]){
            CurrStatus = 0;
        }
        else {
            CurrStatus = 1;
        }
    }
}
State1 = 0
State2 = 0
State3 = 0
print("1 Step, Status:", CurrStatus)
for i in 0...1000{
    random = Double.random(in: 0.000...100.000)
    if random < StatusMatrix[CurrStatus][0]{
        CurrStatus = 0
        State1 += 1
    } else {
        if random > (StatusMatrix[CurrStatus][2] + StatusMatrix[CurrStatus][1] + StatusMatrix[CurrStatus][3]){
            CurrStatus = 2
            State3 += 1
        }
        else{
            CurrStatus = 2
            State2 += 1
        }
    }
    print(i, "Step, status: ", CurrStatus)
    }
