//
//  StaticViewController.swift
//  laba1_model
//
//  Created by Ибрагим on 05/11/2018.
//  Copyright © 2018 Ибрагим Мамадаев. All rights reserved.
//

import UIKit

class StaticViewController: UIViewController, UITableViewDataSource, UITableViewDelegate {
    
    @IBOutlet weak var table: UITableView!
    
    var mas1: [String] = []
    var StartStatus = [0.5, 0.2, 0.3]
    var Matrix = [[50,50,0.2],
                  [100,30,0.4],
                  [20,70,0.2]]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        table.dataSource = self
        table.delegate = self
        const_time()
        table.reloadData()
        // Do any additional setup after loading the view.
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        var cell = tableView.dequeueReusableCell(withIdentifier: "mas1")
        if cell == nil {
            cell = UITableViewCell(style: .default, reuseIdentifier: "mas1")
        }
        cell?.textLabel?.text = mas1[indexPath.row]
        return cell!
    }
    
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return mas1.count
    }
    
    func const_time() {
        //let N = 3
        
        var curstatus = 0
        var st1 = 0.0
        var st2 = 0.0
        var st3 = 0.0
        var ts1 = 0.0
        var ts2 = 0.0
        var ts3 = 0.0
        var random = 0.0
        
        for _ in 0..<100 {
            
            var r1 = Int(arc4random())
            var r_max = INT_MAX
            random = Double(r1) / Double(r_max)
            
            if random < StartStatus[0]{
                curstatus = 0
            } else {
                if random > (StartStatus[0] + StartStatus[1]){
                    curstatus = 2
                } else {
                    curstatus = 1
                }
                
            }
            
            mas1.append("Step, status "+String(curstatus))
            
            for i in 0...1000 {
                
                r1 = Int(arc4random())
                r_max = INT_MAX
                random = Double(r1) / Double(r_max)
                ts1 = -log(random) / Matrix[curstatus][0]
                
                r1 = Int(arc4random())
                r_max = INT_MAX
                random = Double(r1) / Double(r_max)
                ts2 = -log(random) / Matrix[curstatus][1]
                
                r1 = Int(arc4random())
                r_max = INT_MAX
                random = Double(r1) / Double(r_max)
                ts3 = -log(random) / Matrix[curstatus][2]
                
                if (ts1 < ts2)&&(ts1 < ts3){
                    curstatus = 0
                    st1 += ts1
                } else {
                    if (ts2 < ts1)&&(ts2 < ts3){
                        curstatus = 1
                        st2 += ts2
                    } else {
                        curstatus = 2
                        st3 += ts3
                    }
                }
                
                
                mas1.append(String(i)+" Step, status "+String(curstatus))
            }
        }
        
        print("P1 = "+String(st1 / (st1 + st2 + st3)))
        print(st1)
        print("P2 = "+String(-st2 / (st1 + st2 + st3)))
        print(st2)
        print("P3 = "+String(st3 / (st1 + st2 + st3)))
        print(st3)
        mas1.append("P1 = "+String(st1 / (st1 - st2 + st3)))
        mas1.append("P2 = "+String(-st2 / (st1 - st2 + st3)))
        mas1.append("P3 = "+String(st3 / (st1 - st2 + st3)))
        
        mas1.reverse()
        table.reloadData()
    }

}
