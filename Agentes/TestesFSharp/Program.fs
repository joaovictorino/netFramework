open System.Net
open System
open System.IO

[<EntryPoint>]
let main argv = 
    // comentário linha única
    (*comentário
    multi linha*)

    // variáveis imutáveis sem definição de tipo
//    let inteiro = 5
//    let texto = "teste"
//    let valor = 3.5
//
//    //listas
//    let listaInteiro = [1..10]
//
//    //concatenando listas
//    let listaConcatenada = 0 :: listaInteiro //[0..10]
//    let listaConcatenada2 = [0;20] @ listaInteiro
//
//    //declaração dos itens da lista
//    let lista = [2;6;8;9]
//
//    //Funções sem parenteses
//    let square x = x * x
//    square 3 |> printfn "Resultado: %i" 
//
//    let add2times3 = (+) 2 >> (*) 3
//    add2times3 5 |> printfn "Result: %i" 
//
//    // Par é uma subfunção declarada dentro de outra função
//    let Pares lista =
//        let Par x = x%2 = 0
//        List.filter Par lista
//        
//    Pares listaConcatenada2 |> printfn "Lista filtrada %A" 
//
//    // ordem de execução controlada por parenteses
//    List.sum (List.map square [1..100]) |> printfn "Lista soma dos quadrados ate 100: %i" 
//
//    // ordem de execução controlada por pipe
//    [1..100] |> List.map square |> List.sum |> printfn "Lista soma dos quadrados ate 100: %i" 
//
//    // uso de lambda expressions
//    [1..100] |> List.map (fun x -> x * x) |> List.sum |> printfn "Lista soma dos quadrados ate 100: %i" 
//
//    // Pattern matching
//    let MatchSimples x =
//        match x with
//        | "a" -> printfn "A"
//        | "b" -> printfn "B"
//        | _ -> printfn "nada"
//
//    MatchSimples "a"
//    MatchSimples "b"
//    MatchSimples "d"
//
//    //valores nullable
//    let valorQualquer = Some(123)
//    let valorNulo = None
//    
//    let funcaoNulo x =
//        match x with
//        | Some i -> printfn "teste %i" i
//        | None -> printfn "nada de novo"
//        | _ -> printfn "nada de nada"
//
//    funcaoNulo valorQualquer
//    funcaoNulo valorNulo
//
//    let  tupla = [1;2]


    //quicksort verbose f#
    // rec sinaliza que a função é recursiva
//    let rec quicksort list =
//        match list with
//        // lista vazia
//        | [] -> []
//        // se a lista não estiver vazia, pega o primeiro elemento da lista e separa o resto
//        | firstElem::otherElements ->     
//            // primeira função
//            let smallerElements =         
//                otherElements             
//                |> List.filter (fun e -> e < firstElem) 
//                |> quicksort
//            // segunda função
//            let largerElements =
//                otherElements 
//                |> List.filter (fun e -> e >= firstElem)
//                |> quicksort 
//            // junta tudo e retorna
//            List.concat [smallerElements; [firstElem]; largerElements]  
//
//    //test
//    printfn "%A" (quicksort [1;5;23;18;9;1;3])
//
//    let rec quicksort2 = function
//        | [] -> []                         
//        | first::rest -> 
//            let smaller,larger = List.partition ((>=) first) rest 
//            List.concat [quicksort2 smaller; [first]; quicksort2 larger]
//        
//    // test code        
//    printfn "%A" (quicksort2 [1;5;23;18;9;1;3])

    // Fetch the contents of a web page
    let fetchUrl callback url =        
        let req = WebRequest.Create(Uri(url))
        req.Proxy <- WebRequest.GetSystemWebProxy()
        let mycache = CredentialCache()
        mycache.Add(Uri(url), "Basic", NetworkCredential("p017395", "jo@o1984"))
        req.Proxy.Credentials <- mycache
        use resp = req.GetResponse() 
        use stream = resp.GetResponseStream() 
        use reader = new IO.StreamReader(stream) 
        callback reader url

    let myCallback (reader:IO.StreamReader) url = 
        let html = reader.ReadToEnd()
        let html1000 = html.Substring(0,1000)
        printfn "Downloaded %s. First 1000 is %s" url html1000
        html      // return all the html

    //test
    let google = fetchUrl myCallback "http://google.com"
    
    let s = System.Console.ReadKey()
    0 // return an integer exit code
