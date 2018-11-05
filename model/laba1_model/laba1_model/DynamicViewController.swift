//
//  DynamicViewController.swift
//  laba1_model
//
//  Created by Ибрагим on 05/11/2018.
//  Copyright © 2018 Ибрагим Мамадаев. All rights reserved.
//

import UIKit

class DynamicViewController: UIViewController, UITableViewDataSource, UITableViewDelegate {
    
    @IBOutlet weak var table: UITableView!
    
    var mas2: [String] = []
    var StartStatus = [0.5, 0.2, 0.3]
    var Matrix = [[0.6,0.2,0.2],
                  [0.3,0.3,0.4],
                  [0.1,0.7,0.2]]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        table.dataSource = self
        table.delegate = self
        disc_time()
        table.reloadData()
        // Do any additional setup after loading the view.
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        var cell = tableView.dequeueReusableCell(withIdentifier: "mas2")
        if cell == nil {
            cell = UITableViewCell(style: .default, reuseIdentifier: "mas2")
        }
        cell?.textLabel?.text = mas2[indexPath.row]
        return cell!
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return mas2.count
    }
    
    func disc_time() {
        
        var curstatus = 0
        var st1 = 0.0
        var st2 = 0.0
        var st3 = 0.0
        var random = 0.0
        
        for _ in 0..<100 {
            
            var r1 = Int(arc4random())
            var r_max = INT_MAX
            random = Double(r1) / Double(r_max)
            
            if random > (StartStatus[0]+StartStatus[1])  {
                curstatus = 2
            } else {
                if random < StartStatus[0]{
                    curstatus = 0
                } else {
                    curstatus = 1
                }
            }
            
            st1 = 0; st2 = 0; st3 = 0
            
            for i in 0...1000 {
                r1 = Int(arc4random())
                r_max = INT_MAX
                random = Double(r1) / Double(r_max)
                
                if random < Matrix[curstatus][0]  {
                    curstatus = 0
                    st1 += 1
                } else {
                    if random > (Matrix[curstatus][2]+Matrix[curstatus][1]+Matrix[curstatus][0]){
                        curstatus = 2
                        st3 += 1
                    } else {
                        curstatus = 1
                        st2 += 1
                    }
                }
                mas2.append(String(i)+" Step, status "+String(curstatus))
            }
            
        }
        
        mas2.append("Emperic P1 = "+String(st1/1000)+", "+String(StartStatus[0]*Matrix[0][0]+StartStatus[1]*Matrix[1][0]+StartStatus[2]*Matrix[2][0]))
        mas2.append("Emperic P2 = "+String(st2/1000)+", "+String(StartStatus[0]*Matrix[0][1]+StartStatus[1]*Matrix[1][1]+StartStatus[2]*Matrix[2][1]))
        mas2.append("Emperic P3 = "+String(st3/1000)+", "+String(StartStatus[0]*Matrix[0][2]+StartStatus[1]*Matrix[1][2]+StartStatus[2]*Matrix[2][2]))
        
        mas2.reverse()
        table.reloadData()
    }
    
   
    
}
