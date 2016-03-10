### Venn Diagram Example ###
```
/*
Here's how the data items are used:
the first three values specify the relative sizes of three circles, A, B, and C
the fourth value specifies the area of A intersecting B
the fifth value specifies the area of B intersecting C
the sixth value specifies the area of C intersecting A
the seventh value specifies the area of A intersecting B intersecting C
*/
int[] data = new int[] { 100, 80, 60, 30, 30, 30, 10 };

VennDiagram vennDiagram = new VennDiagram(150, 150);
vennDiagram.SetTitle("Venn Diagram");
vennDiagram.SetData(data);

vennDiagram.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=v&chs=150x150&chd=e:BkBQA8AeAeAeAK&chtt=Venn+Diagram)