// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let add x y = x + y
let double x = x * 2

let teste = [2; 3; 5; 6]

let testeArray = [0..100]

let addLambda = (fun x y -> x + y)

let executaFuncao funcao = 
    funcao "parametro 2"

let validar x =
    if(x = "parametro") then
        printfn "deu certo"
    else
        printfn "deu errado"

type book = {Name: string; Rating: int option}

let printNameBook book = match book.Rating with 
                            | Some rating -> printfn "teste %d" rating
                            | None -> printfn "none"

open CSharpLibrary

[<EntryPoint>]
let main argv = 
//    executaFuncao validar
//    let resultado = addLambda 2 2
//    printfn "vai %d" resultado
//    System.Console.WriteLine(teste)
//    System.Console.WriteLine(testeArray)
//    let resultado = List.map(fun x -> x * 2) teste
//    System.Console.WriteLine(resultado)
//    let resultado = List.filter(fun x -> x % 2 = 0) teste    
//    System.Console.WriteLine(resultado)

//    System.Console.Write([0..100]
//    |> List.filter(fun x -> x % 2 = 0)
//    |> List.map(fun x -> x * 2)
//    |> List.sum)

    let livro = {Name = "teste"; Rating= None}
//    let livro2 = {livro with Rating = Some 6}
//    printNameBook livro2
//    System.Console.Write(livro2.Rating)
    let classe = Class1()
    let resultado = classe.somar(5, 5)
    System.Console.WriteLine(classe.X)
    System.Console.WriteLine(resultado)
    System.Console.ReadLine()
    0