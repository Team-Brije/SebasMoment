using System;
using System.Collections.Generic;
using System.Linq;
public static class ListExtensions{
    static Random rng;

    /// <summary>
    /// Mezcla los elementos en la lista usando la implementacion de DurstenField del algoritmo Fisher-Yates
    /// Este metodo modifica el input "list in-place", asegurandose que cada permutacion es pareja, y regresa una lista por el metodo de cambio
    /// Copie este comentario, solo en caso que no  recuerde bien para que se use este codigo
    /// </summary>
    /// <param name="list">La lista por ser mezclada</param>
    /// <typeparam name="T">El tipo de elemento de la lista</typeparam>
    /// <returns>La lista mezclada</returns>
    public static IList<T> Shuffle<T>(this IList<T> list){
        if(rng == null) rng = new Random();
        int count = list.Count;
        while(count > 1){
            --count;
            int index = rng.Next(count + 1);
            (list[index], list[count]) = (list[count], list[index]);
        }

        return list;
    }
}
