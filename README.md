# C-AES-Encrypt

AES算法是美帝政府采用的一种**区块加密标准**的加密法。

AES有3种加密长度：128、192、256
块长度是：128位

具体大家可以参见

http://zh.wikipedia.org/wiki/%E9%AB%98%E7%BA%A7%E5%8A%A0%E5%AF%86%E6%A0%87%E5%87%86

辣么在C#中使用AES算法超级的简单，首先需要using加密类

<pre class="prettyprint">
using System.Security.Cryptography;
</pre>

在这个类下，不单单包含了AES这一种加密算法，还包含了比如DES、DSA等等的算法。

具体参考MSDN

http://msdn.microsoft.com/zh-cn/library/System.Security.Cryptography(v=vs.110).aspx
