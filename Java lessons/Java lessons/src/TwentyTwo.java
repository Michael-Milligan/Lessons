import java.util.*;

public class TwentyTwo {

public static void main(String[] args) {
    Scanner in = new Scanner(System.in);
    int count = in.nextInt();

    int x, y, n, time, pages;

    for (int i = 0; i < count; i++) {
        x = in.nextInt();
        y = in.nextInt();
        n = in.nextInt();
        pages = 0;

        for (time = 1; pages < n; time++) {
            if (time % x == 0 && time % y == 0) {
                pages += 2;
            } else if (time % x == 0 || time % y == 0) {
                pages++;
            }
        }
        System.out.print((time - 1) + " ");
    }
    in.close();
}
}