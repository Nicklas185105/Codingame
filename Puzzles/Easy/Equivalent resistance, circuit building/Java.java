import java.util.*;
import java.io.*;
import java.math.*;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution {

    public static void main(String args[]) {
        Scanner in = new Scanner(System.in);
        int N = in.nextInt();
        Map<String, Integer> resistanceValues = new HashMap<>();
        for (int i = 0; i < N; i++) {
            String name = in.next();
            int R = in.nextInt();
            resistanceValues.put(name, R);
        }
        in.nextLine();

        String circuit = in.nextLine();
        String[] circuitSplit = circuit.split(" ");
        Stack<String> stack = new Stack<>();

        for(int i=0; i< circuitSplit.length; i++) {
            String stringAtI = circuitSplit[i];
            if(! ("]".equals(stringAtI) || ")".equals(stringAtI)) ) {
                if("[".equals(stringAtI) || "(".equals(stringAtI)) {
                    stack.push(stringAtI);
                } else {
                    stack.push(resistanceValues.get(stringAtI).toString());
                }
            } else {
                if (")".equals(stringAtI)) {
                    Double resistanceResult = 0.0;
                    String resistor = stack.pop();
                    while (!"(".equals(resistor)) {
                        resistanceResult += Double.valueOf(resistor);
                        resistor = stack.pop();
                    }
                    stack.push(resistanceResult.toString());
                } else {
                    Double resistanceResult = 0.0;
                    String resistor = stack.pop();
                    while (!"[".equals(resistor)) {
                        resistanceResult += 1 / Double.valueOf(resistor);
                        resistor = stack.pop();
                    }
                    resistanceResult = 1 / resistanceResult;
                    stack.push(resistanceResult.toString());
                }
            }
        }

        System.out.printf("%.1f", Double.valueOf(stack.pop()));
    }
}