module TheIdealStockingStuffer

open System
open System.Security.Cryptography
open System.Text

let private getHash (input: string) =
  let md5Obj = MD5.Create()
  let inputAsBytes = Encoding.ASCII.GetBytes input
  let getHash' index =
    let indexBytes = Encoding.ASCII.GetBytes (string index)
    let byteArr = Array.append inputAsBytes indexBytes
    md5Obj.ComputeHash byteArr
  getHash'

let private findMD5ThatStartsWith (start: string) (str: string) =
  Seq.initInfinite (getHash str)
  |> Seq.map Convert.ToHexString
  |> Seq.indexed
  |> Seq.find (fun (_, h) -> h.StartsWith(start))
  |> fst
  
let bruteForceMD5 = findMD5ThatStartsWith "00000"

let bruteForceMD52 = findMD5ThatStartsWith "000000"
