//
//  main.swift
//  laba1
//
//  Created by Ибрагим Мамадаев on 24.09.2018.
//  Copyright © 2018 Ибрагим Мамадаев. All rights reserved.
//
import Foundation

//print("Hello, World!")
//var randomInt = Int.random(in: 0..<10000)
//print(randomInt)
//var numbers: [Double] = [0.5, 0.2, 0.3]
var StartStatus: [Double] = [0.500, 0.200, 0.300]
var StatusMatrix = [[0.600, 0.200, 0.200],
                    [0.300, 0.300, 0.400],
                    [0.100, 0.700, 0.200]]
var State1 = 0, State2 = 0, State3 = 0, CurrStatus: Int, random: Double
random = 0.000
for _ in 0...100{
    random = Double(Int.random(in: 0...100))/100
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
    //print("1 Step, Status:", CurrStatus)
    for _ in 1...100{
        random = Double(Int.random(in: 0...100))/100
        if random < StatusMatrix[CurrStatus][0]{
            CurrStatus = 0
            State1 += 1
        } else {
            if random > (StatusMatrix[CurrStatus][0] + StatusMatrix[CurrStatus][1]){
                CurrStatus = 2
                State3 += 1
            }
            else{
                CurrStatus = 1
                State2 += 1
            }
        }
        //print(i, "Step, status: ", CurrStatus)
    }
}
print("Эмпирически P1 =", Double(State1)/10000.0)
print("Аналитически P1 =", StartStatus[0] * StatusMatrix[0][0] + StartStatus[1] * StatusMatrix[1][0] + StartStatus[2] * StatusMatrix[2][0])
print()
print("Эмпирически P2 =", Double(State2)/10000.0)
print("Аналитически P2 =", StartStatus[0] * StatusMatrix[0][1] + StartStatus[1] * StatusMatrix[1][1] + StartStatus[2] * StatusMatrix[2][1])
print()
print("Эмпирически P3 =", Double(State3)/10000.0)
print("Аналитически P3 =", round((StartStatus[0] * StatusMatrix[0][2] + StartStatus[1] * StatusMatrix[1][2] + StartStatus[2] * StatusMatrix[2][2])*100)/100)


