//
//  ViewController.swift
//  laba1_model
//
//  Created by Ибрагим on 05/11/2018.
//  Copyright © 2018 Ибрагим Мамадаев. All rights reserved.
//

import UIKit

class ViewController: UIViewController, UITextFieldDelegate {

    @IBOutlet weak var mas1: UITextField!
    @IBOutlet weak var mas2: UITextField!
    @IBOutlet weak var mas3: UITextField!
    
    
    @IBOutlet weak var mtrx1: UITextField!
    @IBOutlet weak var mtrx2: UITextField!
    @IBOutlet weak var mtrx3: UITextField!
    @IBOutlet weak var mtrx4: UITextField!
    @IBOutlet weak var mtrx5: UITextField!
    @IBOutlet weak var mtrx6: UITextField!
    @IBOutlet weak var mtrx7: UITextField!
    @IBOutlet weak var mtrx8: UITextField!
    @IBOutlet weak var mtrx9: UITextField!
    
    var staticButtonPressedFlag: Bool = false
    var dynamicButtonPressedFlag: Bool = false
    var Matrix = [[0.6,50,0.2],
                  [0.3,100,0.4],
                  [0.1,010,0.2]]
    var StartStatus: [Double] = [0.5, 0.2, 0.3]
    
    override func viewDidLoad() {
        
        super.viewDidLoad()
        
        self.mas1.delegate = self
        self.mas2.delegate = self
        self.mas3.delegate = self
        
        self.mtrx1.delegate = self
        self.mtrx2.delegate = self
        self.mtrx3.delegate = self
        self.mtrx4.delegate = self
        self.mtrx5.delegate = self
        self.mtrx6.delegate = self
        self.mtrx7.delegate = self
        self.mtrx8.delegate = self
        self.mtrx9.delegate = self
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        self.view.endEditing(true)
        return false
    }
    
    @IBAction func SaveChangesButton(_ sender: Any) {
        let Dmas1 = Double(mas1.text!) ?? 0.0
        let Dmas2 = Double(mas2.text!) ?? 0.0
        let Dmas3 = Double(mas3.text!) ?? 0.0
        StartStatus.append(Dmas1)
        StartStatus.append(Dmas2)
        StartStatus.append(Dmas3)
        let Dmtrx1 = Double(mas1.text!) ?? 0.0
        let Dmtrx2 = Double(mas1.text!) ?? 0.0
        let Dmtrx3 = Double(mas1.text!) ?? 0.0
        let Dmtrx4 = Double(mas1.text!) ?? 0.0
        let Dmtrx5 = Double(mas1.text!) ?? 0.0
        let Dmtrx6 = Double(mas1.text!) ?? 0.0
        let Dmtrx7 = Double(mas1.text!) ?? 0.0
        let Dmtrx8 = Double(mas1.text!) ?? 0.0
        let Dmtrx9 = Double(mas1.text!) ?? 0.0
        Matrix[0][0] = Dmtrx1
        Matrix[0][1] = Dmtrx2
        Matrix[0][2] = Dmtrx3
        Matrix[1][0] = Dmtrx4
        Matrix[1][1] = Dmtrx5
        Matrix[1][2] = Dmtrx6
        Matrix[2][0] = Dmtrx7
        Matrix[2][1] = Dmtrx8
        Matrix[2][2] = Dmtrx9
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if staticButtonPressedFlag{
            let DestViewControllerDynamic : StaticViewController = segue.destination as! StaticViewController
            DestViewControllerDynamic.StartStatus =  StartStatus
            DestViewControllerDynamic.Matrix =  Matrix
        }
        else if dynamicButtonPressedFlag{
            let DestViewControllerStatic : DynamicViewController = segue.destination as! DynamicViewController
            DestViewControllerStatic.StartStatus =  StartStatus
            DestViewControllerStatic.Matrix =  Matrix
        }
    }
    
    @IBAction func DynamicButtonPressed(_ sender: Any) {
        dynamicButtonPressedFlag = true
        staticButtonPressedFlag = false
    }
    
    @IBAction func StaticButtonPressed(_ sender: Any) {
        dynamicButtonPressedFlag = false
        staticButtonPressedFlag = true
    }
}

